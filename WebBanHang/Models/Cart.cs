using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class Cart
    {
        public ICollection<CartDetail> Details { get; set; }
        public Cart()
        {
            Details = new List<CartDetail>();
        }
        public void Dispatch()
        {

        }
        public void AddCart(int id, string name, int price)
        {
            var check = false;
            foreach (var item in Details)
            {
                if (item.Id == id)
                {
                    item.Amount += 1;
                    check = true; 
                }
            }
            if(!check)
            {
                Details.Add(new CartDetail
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Amount = 1
                });
            }
        }
        public void UpdateAmount(int id, int change)
        {
            foreach (var item in Details)
            {
                if (item.Id == id)
                {
                    if(change==0)
                    {
                        Details.Remove(item);
                        return;
                    }
                    item.Amount = change;
                }
            }
        }
        public void deleteItem(int id)
        {
            UpdateAmount(id, 0);
        }
        public int TongTien()
        {
            return Details.Sum(item => item.Price * item.Amount);
        }
    }
}