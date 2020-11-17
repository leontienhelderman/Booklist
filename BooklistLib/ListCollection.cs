using BooklistLib.DTOs;
using BooklistLib.InterfacesDAL;
using BooklistLib.InterfacesView;
using BooklistLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooklistLib
{
    public class ListCollection : IList
    {
        public IListRepository _listRepository;
        public ListCollection(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public void AddList(ListModel list)
        {
            ListDTO listDTO = ConvertToListDTO(list);
            _listRepository.Create(listDTO);
        }

        public void DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public void EditList(ListModel list)
        {
            throw new NotImplementedException();
        }

        public ListModel GetList(int id)
        {
            throw new NotImplementedException();
        }

        public List<ListModel> GetLists()
        {
            List<ListDTO> listDTOs = _listRepository.GetLists();
            List<ListModel> lists = new List<ListModel>();

            foreach(ListDTO listDTO in listDTOs)
            {
                ListModel list = ConvertToListModel(listDTO);
                lists.Add(list);
            }
            return lists;
        }

        public ListDTO ConvertToListDTO(ListModel list)
        {
            ListDTO listDTO = new ListDTO()
            {
                Name = list.Name,
                Id = list.Id
            };
            return listDTO;
        }

        public ListModel ConvertToListModel(ListDTO listDTO)
        {
            ListModel list = new ListModel()
            {
                Name = listDTO.Name,
                Id = listDTO.Id
            };
            return list;
        }
    }
}
