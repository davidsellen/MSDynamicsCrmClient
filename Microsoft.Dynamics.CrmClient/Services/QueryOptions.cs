using System;
using System.Collections.Generic;

namespace Microsoft.Dynamics.CrmClient
{
    public class QueryOptions
    {
        private int _top;
        private string _logicalOperator;
        public QueryOptions()
        {
            Filters = new List<string>();
            _top = 10;
        }
        public QueryOptions(string logicalOperator = null) : base()
        {

            _logicalOperator = logicalOperator;
        }

        public QueryOptions Contains(string column, object value)
        {

            Filters.Add($"contains({column}, '{value}')");
            return this;
        }
        public QueryOptions Equal(string column, object value)
        {
            Filters.Add(GetComparisonOperation(column, "eq", value));
            return this;
        }

        public QueryOptions NotEqual(string column, object value)
        {
            Filters.Add(GetComparisonOperation(column, "ne", value));
            return this;
        }

        public QueryOptions GreaterThan(string column, object value)
        {
            Filters.Add(GetComparisonOperation(column, "gt", value));
            return this;
        }

        public QueryOptions GreaterThanOrEqual(string column, object value)
        {
            Filters.Add(GetComparisonOperation(column, "ge", value));
            return this;
        }

        public QueryOptions LessThan(string column, object value)
        {
            Filters.Add(GetComparisonOperation(column, "lt", value));
            return this;
        }

        public QueryOptions LessThanOrEqual(string column, object value)
        {
            Filters.Add(GetComparisonOperation(column, "le", value));
            return this;
        }

        private string GetComparisonOperation(string column, string operatorName, object value)
        {
            return $"{column} {operatorName} {ValueFormatter.Format(value)}";
        }

        public QueryOptions Top(int top)
        {
            _top = top;
            return this;
        }

        public override string ToString()
        {
            var expression = new List<string>();
            
            if (Projected.Count > 0)
            {
                expression.Add($"$select={string.Join(",", Projected.ToArray())}");
            }

            if (Filters.Count > 0)
            {
                expression.Add($"$filter={string.Join(_logicalOperator, Filters.ToArray())}");
            }          

            expression.Add($"$top={_top}");

            return string.Join("&", expression);
        }

        public QueryOptions And(QueryOptions height)
        {
            _logicalOperator = " and ";
            Filters.AddRange(height.Filters);
            return this;
        }

        public QueryOptions Or(QueryOptions height)
        {
            _logicalOperator = " or ";
            Filters.AddRange(height.Filters);
            return this;
        }


        public List<string> Filters { get; } = new List<string>();
        public List<string> Projected { get; } = new List<string>();

        internal QueryOptions Select(params string[] attributes)
        {
            Projected.AddRange(attributes);
            return this;
        }
    }

    public static class ValueFormatter
    {

        static readonly Dictionary<Type, Func<object, string>> _formatters = new Dictionary<Type, Func<object, string>>()
        {
             {typeof(string), GetStringValue }
            ,{typeof(int), GetIntValue }
            ,{typeof(DateTime), GetDateTimeValue }
        };

        private static string GetDateTimeValue(object arg)
        {
            DateTime dateTime = (DateTime)arg;
            var roundTripFormat = dateTime.ToUniversalTime().ToString("O");
            return $"datetime{GetStringValue(roundTripFormat)}";
        }

        static string GetIntValue(object arg)
        {
            return $"{arg}";
        }
        static string GetStringValue(object arg)
        {
            return $"'{arg}'";
        }

        public static string Format(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();

            if (!_formatters.ContainsKey(type))
            {
                return value.ToString();
            }

            return _formatters[type].Invoke(value);
        }
    }
}
