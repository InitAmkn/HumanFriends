﻿using HumanFriends.Entity.Enum;

namespace HumanFriends.Entity.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description {  get; set; }

        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
    public interface IBaseResponse<T>
    { 
    T Data { get; }
    StatusCode StatusCode { get; set; }
    string Description { get; set; }
    }
}
