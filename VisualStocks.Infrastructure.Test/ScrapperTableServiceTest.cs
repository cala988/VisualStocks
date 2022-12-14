using FluentAssertions;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VisualStocks.Application.Entities.Scrapper;
using VisualStocks.Application.Interfaces;
using VisualStocks.Application.Services.Finviz;
using VisualStocks.Infrastructure.Services;
using Xunit;
using System.Linq;

namespace VisualStocks.Infrastructure.Test
{
    public class ScrapperTableServiceTest
    {
        private readonly ScrapperTableService _scrapperTableService;

        public ScrapperTableServiceTest()
        {
            _scrapperTableService = new ScrapperTableService(new ScrapperService());
        }

        [Fact]
        public void TestInitializeScrapperTable()
        {
            string json = GetJsonFromFile();

            _scrapperTableService.InitializeScrapperTableFromJsonTableStructure(json);

            _scrapperTableService.ScrapperTable.Cells.Should().HaveCount(72);

            _scrapperTableService.ScrapperTable.GetCell(1, 2)
                .Name.Should().Be("Index");

            _scrapperTableService.ScrapperTable.GetCell(3, 6)
                .Name.Should().Be("EPS next Q");

            _scrapperTableService.ScrapperTable.Cells.ForEach(x => x.Value.Should().BeNull());
        }

        [Fact]
        public void TestAddCellToScrapperTable()
        {
            const string NameOfCell1 = "Name of Cell 1";
            const string NameOfCell2 = "Name of Cell 2";
            const string NameOfCell3 = "Name of Cell 3";

            ScrapperTable sp = new();
            sp.AddCell(1, 1, NameOfCell1);
            sp.AddCell(1, 2, NameOfCell2);
            sp.AddCell(2, 1, NameOfCell3);

            sp.Cells.Count.Should().Be(3);

            sp.Cells.ForEach(x => x.Value.Should().BeNull());
            _ = sp.Cells.Where(x => x.Row == 1 && x.Column == 2).Select(x => x.Name).FirstOrDefault().Should().Be(NameOfCell2);

        }

        private string GetJsonFromFile()
        {
            const string JsonFileName = "Data\\jsonTableFinviz.json";
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + JsonFileName);

            using StreamReader r = new StreamReader(jsonFilePath);
            string json = r.ReadToEnd();
            return json;
            //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
    }
}
