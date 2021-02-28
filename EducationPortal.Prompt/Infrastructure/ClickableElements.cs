using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Prompt.Infrastructure
{
    public static class ClickableElements
    {
        private static List<Action> _actions;

        public static void Show(IEnumerable<string> names, IEnumerable<Action> actions)
        {
            Console.Clear();

            var namesList = names.ToList();
            if (namesList.Count != actions.Count())
            {
                throw new Exception("Amount of action names and actions not equal");
            }

            _actions = actions.ToList();

            for (int i = 0; i < namesList.Count; i++)
            {
                Console.WriteLine($"({i}) {namesList[i]}");
            }
        }

        public static void Execute(int actionIndex)
        {
            if (actionIndex >= 0 && actionIndex < _actions.Count)
            {
                Console.Clear();
                _actions[actionIndex].Invoke();
                _actions.Clear();
            }
        }

        public static void Show(IEnumerable<(string, Action)> clickableElement)
        {
            for (int i = 0; i < clickableElement.Count(); i++)
            {
                Console.WriteLine($"({i}) {clickableElement.ElementAt(i).Item1}");
            }
        }
    }
}
