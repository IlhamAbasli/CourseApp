﻿using Repository.Repository;
using Repository.Repository.Interface;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public void Create(Group group)
        {
            _groupRepository.Create(group);
        }

        public bool Delete(int id)
        {
            return _groupRepository.Delete(id);
        }

        public void Edit(int id, Group group)
        {
            _groupRepository.Edit(id, group);
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group GetById(int id)
        {
            return _groupRepository.GetById(id);
        }

        public List<Group> Search(string searchText)
        {
           return _groupRepository.Search(searchText);
        }

        public List<Group> Sort()
        {
            return _groupRepository.Sort();
        }
    }
}
