using AdminDaviBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDaviBus.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
            menu.Add(new Navbar { Id = 2, nameOption = "Quản lý", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 3, nameOption = "Danh sách hóa đơn", controller = "DmHoaDon", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 4, nameOption = "Danh sách tài xế", controller = "DmTaiXe", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 5, nameOption = "Danh sách trạm", controller = "DmTram", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 6, nameOption = "Danh sách dich vu", controller = "DichVu", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id =7, nameOption = "Danh sách tuyến", controller = "DmTuyen", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id =8, nameOption = "Danh sách chi tiết trạm", controller = "ChiTietTram", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id =9, nameOption = "Danh sách xe", controller = "DmXe", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id =10, nameOption = "Danh lộ trình cho xe", controller = "LoTrinhChoXe", action = "Index", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id =11, nameOption = "Báo cáo", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 12, nameOption = "Báo cáo tuyến", controller = "Report", action = "BaoCaoTuyen", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 12, nameOption = "Báo cáo hóa đơn", controller = "Report", action = "BaoCaoHoaDon", status = true, isParent = false, parentId = 11 });

              return menu.ToList();
        }
    }
}