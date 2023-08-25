using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Application
{
    public class OperationResult
    {
        public OperationResult()
        {
            this.IsSuccess=false;
        }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int Code { get; set; }


        public OperationResult Success(int Code, string Message="عملیات با موفقیت  انجام شد .")
        {
            this.Code = Code;
            this.Message = Message;
            IsSuccess = true;
            return this;
        }


        public OperationResult Failed(int Code, string Message = "خطا در  انجام عملیات!!!")
        {
            this.Code = Code;
            this.Message = Message;
            IsSuccess = false;
            return this;
        }
    }
}
