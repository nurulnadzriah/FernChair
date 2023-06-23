using FernChair.Model;
using System;
using System.Collections.Generic;

namespace FernChair
{
    public class FernChairPacking
    {
        private List<Store> stores;

        /// <summary>
        /// Pre requisite hard coded : 
        ///     Initialise stores
        /// </summary>
        public FernChairPacking()
        {
            stores = InitialiseStores();
        }

        public void PackFernChairs(Int64 numOfChairs)
        {
            // Start Packing
            if (numOfChairs > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("OUTPUT");
                Console.WriteLine("------------------------------------------");

                for (int i = 1; i <= numOfChairs; i++)
                {
                    string boxName = "BoxFern" + i;
                    Console.WriteLine(boxName);

                    foreach (Component requiredComponent in InitialiseComponents())
                    {
                        bool isComponentFound = false;
                        int currentStore = 0;

                        foreach (Store store in stores)
                        {
                            currentStore += 1;

                            Component storeComponent = store.Components.Find(c => c.Name == requiredComponent.Name);

                            if (storeComponent is null)
                            {
                                // Find the required component at another store
                            }
                            else
                            {
                                if (storeComponent.Quantity > 0)
                                {
                                    int quantityToPick = Math.Min(requiredComponent.Quantity, storeComponent.Quantity);
                                    storeComponent.Quantity -= quantityToPick;
                                    requiredComponent.Quantity -= quantityToPick;

                                    isComponentFound = true;

                                    if (currentStore == stores.Count)
                                    {
                                        if (requiredComponent.Quantity <= quantityToPick)
                                        {
                                            if (requiredComponent.Quantity > storeComponent.Quantity)
                                            {
                                                isComponentFound = false;
                                                break;
                                            }
                                            else
                                                Console.WriteLine($"{store.Name} | {requiredComponent.Name} = {quantityToPick}");
                                        }
                                        else
                                        {
                                            isComponentFound = false;
                                            break;
                                        }
                                    }
                                    else
                                        Console.WriteLine($"{store.Name} | {requiredComponent.Name} = {quantityToPick}");



                                    if (requiredComponent.Quantity == 0)
                                        break;
                                }
                                else
                                {
                                    // Find the required component at another store
                                }
                            }
                        }

                        if (!isComponentFound) // stop packing immediately
                        {
                            Console.WriteLine("##########{ERROR}: Insufficient stock for component " + requiredComponent.Name + "##########");
                            return;
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("##########{ERROR}: Invalid Input Value.##########");
        }

        #region "PRE REQUISITES"

        /// <summary>
        /// Pre requisite hard coded : 
        /// A Fern chair requires; [screw=10, wheel=4, armbar=2, nut=30]
        /// </summary>
        /// <returns></returns>
        private List<Component> InitialiseComponents()
        {
            return new List<Component>
            {
                new Component { Name = "screw", Quantity = 10 },
                new Component { Name = "wheel", Quantity = 4 },
                new Component { Name = "armbar", Quantity = 2 },
                new Component { Name = "nut", Quantity = 30 }
            };
        }

        /// <summary>
        /// Pre requisite hard coded : 
        ///     Store01 has [screw=20, wheel=8, armbar=4, nut=20]
        ///     Store02 has[screw = 100, wheel = 100, armbar = 100, nut = 20]
        ///     Store03 has[screw = 2000, wheel = 200, armbar = 100, nut = 1000]
        /// </summary>
        /// <returns></returns>
        private List<Store> InitialiseStores()
        {
            return new List<Store>()
            {
                //Store01 has [screw=20, wheel=8, armbar=4, nut=20]
                new Store
                {
                    Name = "Store01",
                    Components = new List<Component>()
                    {
                        new Component { Name = "screw", Quantity = 20 },
                        new Component { Name = "wheel", Quantity = 8 },
                        new Component { Name = "armbar", Quantity = 4 },
                        new Component { Name = "nut", Quantity = 20 }
                    }
                },
                //Store02 has[screw = 100, wheel = 100, armbar = 100, nut = 20]
                new Store
                {
                    Name = "Store02",
                    Components = new List<Component>()
                    {
                        new Component { Name = "screw", Quantity = 100 },
                        new Component { Name = "wheel", Quantity = 100 },
                        new Component { Name = "armbar", Quantity = 100 },
                        new Component { Name = "nut", Quantity = 20 }
                    }
                },
                //Store03 has[screw = 2000, wheel = 200, armbar = 100, nut = 1000]
                new Store
                {
                    Name = "Store03",
                    Components = new List<Component>()
                    {
                        new Component { Name = "screw", Quantity = 2000 },
                        new Component { Name = "wheel", Quantity = 200 },
                        new Component { Name = "armbar", Quantity = 100 },
                        new Component { Name = "nut", Quantity = 1000 }
                    }
                }
            };
        }

        #endregion
    }
}
