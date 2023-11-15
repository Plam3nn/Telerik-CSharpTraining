using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_InventoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new HashSet<Item>();
            var itemsByTypes = new Dictionary<string, List<Item>>();

            var output = new StringBuilder();

            while (true)
            {
                var inputArguments = Console.ReadLine().Split();
                var command = inputArguments[0];

                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    var name = inputArguments[1];
                    var price = decimal.Parse(inputArguments[2]);
                    var type = inputArguments[3];

                    var item = new Item(name, price, type);

                    if (items.Contains(item))
                    {
                        output.AppendLine($"Error: Item {name} already exists");
                        continue;
                    }

                    items.Add(item);

                    if (!itemsByTypes.ContainsKey(type))
                    {
                        itemsByTypes[type] = new List<Item>();    
                    }

                    itemsByTypes[type].Add(item);

                    output.AppendLine($"Ok: Item {name} added successfully");
                }
                else if (command == "filter")
                {
                    var filterByArg = inputArguments[2];

                    if (filterByArg == "type")
                    {
                        var type = inputArguments[3];

                        if (!itemsByTypes.ContainsKey(type))
                        {
                            output.AppendLine($"Error: Type {type} does not exist");
                            continue;
                        }

                        var filtered = itemsByTypes[type]
                            .OrderBy(i => i.Price)
                            .ThenBy(i => i.Name)
                            .ThenBy(i => i.Type)
                            .Take(10);

                        output.AppendLine(GenerateOutput(filtered));
                    }
                    else if (filterByArg == "price")
                    {
                        if (inputArguments.Length == 7)
                        {
                            var minPrice = decimal.Parse(inputArguments[4]);
                            var maxPrice = decimal.Parse(inputArguments[6]);

                            var filtered = items
                                .Where(i => i.Price >= minPrice && i.Price <= maxPrice)
                                .OrderBy(i => i.Price)
                                .ThenBy(i => i.Name)
                                .ThenBy(i => i.Type)
                                .Take(10);

                            output.AppendLine(GenerateOutput(filtered));
                        }
                        else
                        {
                            var condition = inputArguments[3]; // from or to

                            if (condition == "from")
                            {
                                var minPrice = decimal.Parse(inputArguments[4]);

                                var filtered = items
                                    .Where(i => i.Price >= minPrice)
                                    .OrderBy(i => i.Price)
                                    .ThenBy(i => i.Name)
                                    .ThenBy(i => i.Type)
                                    .Take(10);

                                output.AppendLine(GenerateOutput(filtered));
                            }
                            else if (condition == "to")
                            {
                                var maxPrice = decimal.Parse(inputArguments[4]);

                                var filtered = items
                                    .Where(i => i.Price <= maxPrice)
                                    .OrderBy(i => i.Price)
                                    .ThenBy(i => i.Name)
                                    .ThenBy(i => i.Type)
                                    .Take(10);

                                output.AppendLine(GenerateOutput(filtered));
                            }
                        }
                    }
                }
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        private static string GenerateOutput(IEnumerable<Item> items)
        {
            if (items.Any())
            {
                return $"Ok: {string.Join(", ", items)}";
            }
            else
            {
                return$"Ok: ";
            }
        }
    }

    internal class Item
    {
        public Item(string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; }

        public decimal Price { get; }

        public string Type { get; }

        public override string ToString()
        {
            return $"{this.Name}({this.Price:f2})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Item))
            {
                return false;
            }

            return this.Name == ((Item)obj).Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
