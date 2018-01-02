using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiQA.Utils.DataAccess
{
    class DataResult : IEnumerable<Dictionary<string, object>>
    {
        List<Dictionary<string, object>> rows;
        public DataResult()
        {

        }
        public IEnumerator<Dictionary<string, object>> GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return rows.GetEnumerator();
        }
        public void AddRow(string[] fields, object[] values)
        {
            Dictionary<string, object> newrow = new Dictionary<string, object>();
            for (int i = 0; i < fields.Length; i++)
            {
                newrow.Add(fields[i], values[i]);
            }
            rows.Add(newrow);
        }
    }
}
