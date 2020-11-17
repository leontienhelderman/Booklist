using BooklistLib.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib.InterfacesDAL
{
    public interface IListRepository
    {
        List<ListDTO> GetLists();

        ListDTO GetList(int id);

        void Create(ListDTO list);

        void Update(ListDTO list);

        void Delete(int id);
    }
}
