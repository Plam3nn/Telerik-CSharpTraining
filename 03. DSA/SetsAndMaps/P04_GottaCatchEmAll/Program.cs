using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_GottaCatchEmAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pokemons = new List<Pokemon>();
            var pokemonsByType = new Dictionary<string, List<Pokemon>>();
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
                    var type = inputArguments[2];
                    var power = byte.Parse(inputArguments[3]);
                    var position = int.Parse(inputArguments[4]);

                    var pokemon = new Pokemon(name, type, power);

                    if (position > pokemons.Count)
                    {
                        pokemons.Add(pokemon);
                    }
                    else
                    {
                        pokemons.Insert(position - 1, pokemon);
                    }

                    if (!pokemonsByType.ContainsKey(type))
                    {
                        pokemonsByType.Add(type, new List<Pokemon>());
                    }

                    pokemonsByType[type].Add(pokemon);

                    output.AppendLine($"Added pokemon {name} to position {position}");
                }
                else if (command == "find")
                {
                    var type = inputArguments[1];

                    if (!pokemonsByType.ContainsKey(type))
                    {
                        output.AppendLine($"Type {type}: ");
                    }
                    else
                    {
                        var filtered = pokemonsByType[type]
                            .OrderBy(p => p.Name)
                            .ThenByDescending(p => p.Power)
                            .Take(5);

                        output.AppendLine($"Type {type}: {string.Join("; ", filtered)}");
                    }
                }
                else if (command == "ranklist")
                {
                    var start = int.Parse(inputArguments[1]);
                    var end = int.Parse(inputArguments[2]);

                    for (int i = start; i <= end; i++)
                    {
                        output.Append($"{i}. {pokemons[i - 1]}");

                        if (i < end)
                        {
                            output.Append("; ");
                        }
                    }

                    output.AppendLine();
                }
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }
    }

    internal class Pokemon
    {
        public Pokemon(string name, string type, byte power)
        {
            this.Name = name;
            this.Type = type;
            this.Power = power;
        }

        public string Name { get; }

        public string Type { get; }

        public byte Power { get; }

        public override string ToString()
        {
            return $"{this.Name}({this.Power})";
        }
    }
}