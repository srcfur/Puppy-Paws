using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Inventory
{
    public int GetInventorySize();
    public ItemStack? Get(int index);
    public void Set(int index, ItemStack? item);
    
}