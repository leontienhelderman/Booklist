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
        private readonly IListRepository _listRepository;
        public ListCollection(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public ListCollection()
        {

        }

        public void AddList(ListModel list)
        {
            ListDTO listDTO = ConvertToListDTO(list);
            _listRepository.Create(listDTO);
        }

        public void DeleteList(int id)
        {
            _listRepository.Delete(id);
        }

        public void EditList(ListModel list)
        {
            ListDTO listDTO = ConvertToListDTO(list);
            _listRepository.Update(listDTO);
        }

        public ListModel GetList(int id)
        {
            ListDTO listDTO;
            listDTO = _listRepository.GetList(id);
            ListModel list = ConvertToListModel(listDTO);
            return list;
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
