using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Builders
{
    class ScrapeCriteriaBuilder : ScrapeCriteria
    {

        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaPart> _parts;

        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();

        }
        public ScrapeCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }
        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOptions)
        {
            _regexOption = regexOptions;
            return this;
        }
        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _parts.Add(scrapeCriteriaPart);
            return this;
        }
        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Parts = _parts;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOption = _regexOption;

            return scrapeCriteria;
        }


    }
}
