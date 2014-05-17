namespace Microsoft.AspNet.Routing
{
    internal class InlineParameterParseResult
    {
        public string ParameterName { get; set; }

        public IRouteConstraint InlineConstraint { get; set; }

        public object DefaultValue { get; set; }

        public bool HasDefaultValue { get; set; }
    }
}