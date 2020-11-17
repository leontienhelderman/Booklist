using BooklistLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.InterfacesView
{
    public interface IList
    {
        List<ListModel> GetLists();

        ListModel GetList(int id);

        void AddList(ListModel list);

        void EditList(ListModel list);

        void DeleteList(int id);
    }
}
