using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Sln_Noums
{
    public class PoductTest: IProductTest
    {
        public int IdProd { get; set; }
        public string Name { get; set; }

        public IEnumerable<PoductTest> GetAllProductTest()
        {
            List<PoductTest> Prods = new List<PoductTest>()
            {
                new PoductTest{IdProd =1, Name="prod1"},
                new PoductTest{IdProd =2, Name="prod2"},
                new PoductTest{IdProd =3, Name="prod13"}
            };
           return  Prods.ToList();
           
        }
    }
    public interface IProductTest
    {
        IEnumerable<PoductTest> GetAllProductTest();
    }
}
