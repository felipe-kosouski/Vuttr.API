using System;
using System.Collections.Generic;
using System.Linq;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using Vuttr.API.Data.Context;
using Vuttr.API.Data.Repository;
using Vuttr.API.Domain.DTO.Tool;
using Vuttr.API.Domain.Models;
using Vuttr.API.Domain.Repository;
using Vuttr.API.Domain.RequestFeatures;
using Xunit;

namespace Vuttr.Tests.Repository
{
    public class ToolRepositoryTests
    {
        private IEnumerable<Tool> GetFakeData()
        {
            var tools = A.ListOf<Tool>(20);
            return tools;
        }

        //Testing the get all tools and the pagination, generated 20 tools, the default page size is 10, so we expect 10 tools
        [Fact]
        public void GetToolsTest()
        {
            var toolParameters = new ToolParameters();
            var repository = new Mock<IToolRepository>();
            var tools = GetFakeData();
            var pagedTools = PagedList<Tool>.ToPagedList(tools, toolParameters.PageNumber, toolParameters.PageSize);
            repository.Setup(x => x.GetAllToolsAsync(toolParameters, false))
                .ReturnsAsync(pagedTools);
            Assert.Equal(10, pagedTools.Count());
        }

        [Fact]
        public void GetToolTest()
        {
            var repository = new Mock<IToolRepository>();
            Tool tool = new Tool
            {
                Id = Guid.NewGuid(),
                Title = "Postgre SQL",
                Description = "Database Tool",
                Link = "http://postgres.com",
                Tags = new[]
                {
                    "db",
                    "postgre",
                    "sql"
                }
            };
            repository.Setup(x => x.GetToolAsync(It.IsAny<Guid>(), false)).ReturnsAsync(tool);
            Assert.NotNull(tool);
            Assert.IsAssignableFrom<Tool>(tool);
        }

        [Fact]
        public void AddToolTest()
        {
            var repository = new Mock<IToolRepository>();
            var tools = GetFakeData();
            Tool tool = new Tool
            {
                Id = Guid.NewGuid(),
                Title = "teste lol",
                Description = "Database Tool",
                Link = "http://postgres.com",
                Tags = new[]
                {
                    "db",
                    "postgre",
                    "sql"
                }
            };
            repository.Setup(x => x.CreateTool(tool));
        }

        [Fact]
        public void UpdateToolTest()
        {
            
        }

        [Fact]
        public void RemoveToolTest()
        {
            
        }
        
    }
}