using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Exceptions
{
    public class TaskException : Exception
    {
        public TaskException() :base(message:"Task not found")
        {
        }
    }
}
