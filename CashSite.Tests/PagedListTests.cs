using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSite.Tests
{
    [TestClass]
    public class PagedListTests
    {
        List<int> stringRepo = new List<int>();

        [TestInitialize]
        public void InitRepo()
        {
            for(var i = 1; i <= 150; i++)
                stringRepo.Add(i);
        }

        [TestMethod]
        public void TestPagedList_Initialization()
        {
            int page = 0;
            int pageSize = 150;

            PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), page, pageSize);

            Assert.AreEqual(150, pagedList.TotalResults);
            Assert.AreEqual(1, pagedList.Results.First());
            Assert.AreEqual(150, pagedList.Results.Last());
        }

        [TestMethod]
        public void TestPagedList_PagingBasic()
        {
            int page = 3;
            int pageSize = 10;

            PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), page, pageSize);
            
            Assert.AreEqual(31, pagedList.Results.First());
            Assert.AreEqual(40, pagedList.Results.Last());
        }

        [TestMethod]
        public void TestPagedList_PagingSmallPage()
        {
            int page = 5;
            int pageSize = 2;

            PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), page, pageSize);

            Assert.AreEqual(11, pagedList.Results.First());
            Assert.AreEqual(12, pagedList.Results.Last());
        }

        [TestMethod]
        public void TestPagedList_PagingLargePage()
        {
            int page = 1;
            int pageSize = 149;

            PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), page, pageSize);

            Assert.AreEqual(150, pagedList.Results.First());
            Assert.AreEqual(150, pagedList.Results.Last());
        }

        [TestMethod]
        public void TestPagedList_PagingInvalidInput()
        {
            int page = 15;
            int pageSize = 50;

            Assert.ThrowsException<ArgumentException>(() => {
                PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), page, pageSize);
            });

            Assert.ThrowsException<ArgumentException>(() => {
                PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), -1, pageSize);
            });

            Assert.ThrowsException<ArgumentException>(() => {
                PagedList<int> pagedList = new PagedList<int>(stringRepo.AsQueryable(), page, 0);
            });
        }

        public class PagedList<T>
        {
            public int TotalResults { get; private set; }

            public List<T> Results { get; private set; }

            public PagedList(IQueryable<T> query, int page, int pageSize)
            {
                var totalCount = query.Count();

                if (page < 0)
                    throw new ArgumentException("Page must be greater than 0.");

                if (pageSize < 1)
                    throw new ArgumentException("Page size must be greater than or equal to 1.");

                if (totalCount < (page + 1) * pageSize)
                    throw new ArgumentException("Invalid page number or page size.");
                
                TotalResults = query.Count();
                Results = query
                    .Skip(page * pageSize)
                    .Take(pageSize).ToList();
            }
        }
    }
}
