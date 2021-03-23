using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            StringBuilder elements = new StringBuilder();

            for (int i = 0; i < namesList.Count; i++)
            {
                elements.AppendLine($"({i}) {namesList[i]}");
            }

            Console.WriteLine(elements.ToString());
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
    }
}
