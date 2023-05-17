using LeapYearsv3.Models;
using Microsoft.AspNetCore.Http;
using PagedList;
using System.Drawing.Printing;

namespace LeapYearsv3.ViewModels
{
    public class ListAndUserVm
    {
        public string UserNumber;
        public PagedList.IPagedList<LeapYearsv3.Models.Search> List;
        public int currentPage;
    }
}
