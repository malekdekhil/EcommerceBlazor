using Domains;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class ShoppingUserTmp : IShoppingUserTmp
    {
        private UserTmp _UserTmp { get; set; }
        private readonly ProtectedLocalStorage LocalStorage;
        private IUserTmp userTmpService { get; set; }
        private ICart carteService { get; set; }
        public ShoppingUserTmp(){}
        public ShoppingUserTmp(UserTmp UserTmp)
        {
            _UserTmp = UserTmp;
        }
        public ShoppingUserTmp(IUserTmp userTmpService, ICart carteService, ProtectedLocalStorage LocalStorage)
        {
            this.LocalStorage = LocalStorage;
            this.userTmpService = userTmpService;
            this.carteService = carteService;
        }
        public async Task<UserTmp> InitializeShoppingUserTmp()
        {
            var result = await LocalStorage.GetAsync<UserTmp>("UserTmp");
            return _UserTmp = result.Success ? result.Value : new UserTmp();
        }
        public async Task AddInfoUserTmp()
        {
            await userTmpService.AddUserTmp(_UserTmp);
        }
        public async Task TransactionOrderUserTmp()
        {   //step 1 save info
             await LocalStorage.SetAsync("UserTmp", _UserTmp);
            //step 2 check disponibily product
            //step 3 validation paypal
            //step 4 save in db
            //step 5 generate invoice
            //step 6 clear info localstorage
            //...
        }

        public async Task ClearInfoUserTmp()
        {
            await LocalStorage.DeleteAsync("UserTmp");
            await LocalStorage.SetAsync("UserTmp", _UserTmp);
        }
    }
}
