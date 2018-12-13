using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FakeItEasy;
using CaesarCipher;
using CaesarCipher.WikiSearch;

namespace CaesarCipher.Tests
{
    public class SearchCryptAndPrintResultTests
    {
        private readonly IWikipediaClient _client;
        private readonly SearchCryptAndPrintResult _runner;
        private readonly Action<string> _writeLine;

        public SearchCryptAndPrintResultTests()
        {
            _client = A.Fake<IWikipediaClient>();
            _runner = new SearchCryptAndPrintResult(_client);
            _writeLine = A.Fake<Action<string>>();
        }

        [Theory]
        [InlineData(
            "norway",
            3,
            "{\"batchcomplete\":\"\",\"continue\":{\"sroffset\":10,\"continue\":\"-||\"},\"query\":{\"searchinfo\":{\"totalhits\":169712},\"search\":[{\"ns\":0,\"title\":\"Norway\",\"pageid\":21241,\"size\":226140,\"wordcount\":22145,\"snippet\":\"<span class=\\\"searchmatch\\\">Norway</span> (<span class=\\\"searchmatch\\\">Norwegian</span>: Norge (Bokmål) or Noreg (Nynorsk); Northern Sami: Norga), officially the Kingdom of <span class=\\\"searchmatch\\\">Norway</span>, is a Nordic country in Northwestern Europe\",\"timestamp\":\"2018-12-12T14:10:21Z\"},{\"ns\":0,\"title\":\"Norwegians\",\"pageid\":671747,\"size\":33041,\"wordcount\":3311,\"snippet\":\"<span class=\\\"searchmatch\\\">Norwegians</span> (<span class=\\\"searchmatch\\\">Norwegian</span>: nordmenn) are a North Germanic ethnic group native to <span class=\\\"searchmatch\\\">Norway</span>. They share a common culture and speak the <span class=\\\"searchmatch\\\">Norwegian</span> language. Norwegian\",\"timestamp\":\"2018-11-15T20:53:23Z\"},{\"ns\":0,\"title\":\"Norwegian\",\"pageid\":63695,\"size\":1561,\"wordcount\":188,\"snippet\":\"<span class=\\\"searchmatch\\\">Norwegian</span>, Norwayan, or Norsk may refer to: Something of, from, or related to <span class=\\\"searchmatch\\\">Norway</span>, a country in northwestern Europe <span class=\\\"searchmatch\\\">Norwegians</span>, both a nation and an\",\"timestamp\":\"2018-10-15T12:23:30Z\"},{\"ns\":0,\"title\":\"Norwegian Campaign\",\"pageid\":1090694,\"size\":135920,\"wordcount\":15393,\"snippet\":\"The <span class=\\\"searchmatch\\\">Norwegian</span> Campaign was the attempted Allied liberation of the Scandinavian nation of <span class=\\\"searchmatch\\\">Norway</span> from Nazi Germany during the early stages of World War\",\"timestamp\":\"2018-11-22T18:12:11Z\"},{\"ns\":0,\"title\":\"Norway–European Union relations\",\"pageid\":3982602,\"size\":27885,\"wordcount\":2450,\"snippet\":\"The Kingdom of <span class=\\\"searchmatch\\\">Norway</span> is not a member state of the European Union (EU). It is associated with the Union through its membership in agreements in the European\",\"timestamp\":\"2018-11-17T10:33:18Z\"},{\"ns\":0,\"title\":\"Denmark–Norway\",\"pageid\":21485871,\"size\":28403,\"wordcount\":2649,\"snippet\":\"Denmark–<span class=\\\"searchmatch\\\">Norway</span> (Danish and <span class=\\\"searchmatch\\\">Norwegian</span>: Danmark–Norge), also known as the Dano-<span class=\\\"searchmatch\\\">Norwegian</span> Realm, the Oldenburg Monarchy or the Oldenburg realms, was an early\",\"timestamp\":\"2018-12-12T12:45:05Z\"},{\"ns\":0,\"title\":\"Norwegian cuisine\",\"pageid\":2215144,\"size\":24773,\"wordcount\":3569,\"snippet\":\"<span class=\\\"searchmatch\\\">Norwegian</span> cuisine in its traditional form is based largely on the raw materials readily available in <span class=\\\"searchmatch\\\">Norway</span> and its mountains, wilderness, and coast.\",\"timestamp\":\"2018-11-22T11:51:28Z\"},{\"ns\":0,\"title\":\"Oslo\",\"pageid\":22309,\"size\":111542,\"wordcount\":10214,\"snippet\":\"Oslo (/ˈɒzloʊ/ OZ-loh; <span class=\\\"searchmatch\\\">Norwegian</span>: [²ʊʂlʊ] (listen), rarely [²ʊslʊ, ˈʊʂlʊ]) is the capital and most populous city of <span class=\\\"searchmatch\\\">Norway</span>. It constitutes both a county\",\"timestamp\":\"2018-12-11T20:52:45Z\"},{\"ns\":0,\"title\":\"Harald Fairhair\",\"pageid\":56251,\"size\":30298,\"wordcount\":3567,\"snippet\":\"hárfagri, <span class=\\\"searchmatch\\\">Norwegian</span>: Harald hårfagre; putatively c. 850 – c. 932) is portrayed by medieval Icelandic historians as the first King of <span class=\\\"searchmatch\\\">Norway</span>. According\",\"timestamp\":\"2018-11-28T21:56:21Z\"},{\"ns\":0,\"title\":\"Aristocracy of Norway\",\"pageid\":2144715,\"size\":215877,\"wordcount\":15717,\"snippet\":\"Aristocracy of <span class=\\\"searchmatch\\\">Norway</span> refers to modern and medieval aristocracy in <span class=\\\"searchmatch\\\">Norway</span>. Additionally, there have been economical, political, and military élites that—relating\",\"timestamp\":\"2018-12-12T15:04:13Z\"}]}}",
            "Norway, is a Nordic country in Northwestern Europe",
            "vsdqcfodvvvhdufkpdwfkqruzdøvsdqcvsdqcfodvvvhdufkpdwfkqruzhjldqvsdqcqrujhcernpbocrucqruhjcqøqruvncqruwkhuqcvdplcqrujdcriilfldooøcwkhcnlqjgrpcricvsdqcfodvvvhdufkpdwfkqruzdøvsdqclvcdcqruglfcfrxqwuøclqcqruwkzhvwhuqchxursh",
            false)]
        [InlineData(
            "computas",
            -7,
            "{\"batchcomplete\":\"\",\"continue\":{\"sroffset\":10,\"continue\":\"-||\"},\"query\":{\"searchinfo\":{\"totalhits\":17,\"suggestion\":\"computer\",\"suggestionsnippet\":\"<em>computer</em>\"},\"search\":[{\"ns\":0,\"title\":\"Metis (software)\",\"pageid\":2988291,\"size\":2225,\"wordcount\":288,\"snippet\":\"and product was sold to <span class=\\\"searchmatch\\\">Computas</span> AS. In 2004 <span class=\\\"searchmatch\\\">Computas</span> AS was split into two: <span class=\\\"searchmatch\\\">Computas</span>, and <span class=\\\"searchmatch\\\">Computas</span> Technology. In 2005 <span class=\\\"searchmatch\\\">Computas</span> Technology was merged with\",\"timestamp\":\"2017-07-24T12:32:24Z\"},{\"ns\":0,\"title\":\"Geco (Geophysical Company of Norway)\",\"pageid\":2146011,\"size\":4697,\"wordcount\":455,\"snippet\":\"Limited as the solely owner from 1993. The company started as Geoteam-<span class=\\\"searchmatch\\\">Computas</span> Ltd. A.S on December 13, 1972. The name was shortly afterwards changed\",\"timestamp\":\"2018-06-05T03:56:33Z\"},{\"ns\":0,\"title\":\"Kath & Kim\",\"pageid\":376185,\"size\":37147,\"wordcount\":2918,\"snippet\":\"child Kimberly (Kim) Diane Craig née Poole (Gina Riley), Kim's husband and <span class=\\\"searchmatch\\\">Computa</span> City salesman, Brett Craig (Peter Rowsthorn), Kath's love interest and\",\"timestamp\":\"2018-12-09T07:11:08Z\"},{\"ns\":0,\"title\":\"Landsat 7\",\"pageid\":473823,\"size\":11327,\"wordcount\":1075,\"snippet\":\"(found in Google Earth and Google Maps) from TerraMetrics, BrightEarth from <span class=\\\"searchmatch\\\">Computa</span>Maps, simulated natural color from Atlogis and a product of i-cubed used\",\"timestamp\":\"2018-02-18T20:14:39Z\"},{\"ns\":0,\"title\":\"List of Kath & Kim characters\",\"pageid\":16673200,\"size\":16050,\"wordcount\":1802,\"snippet\":\"navy throughout his youth. Brett Craig is Kim's husband. Brett works at <span class=\\\"searchmatch\\\">Computa</span> City and is married to Kim Craig (Gina Riley) from the start of the series\",\"timestamp\":\"2018-12-05T23:26:25Z\"},{\"ns\":0,\"title\":\"Guyanese Creole\",\"pageid\":2078159,\"size\":6015,\"wordcount\":658,\"snippet\":\"and its corresponding sound with &quot;-a&quot;; for example, &quot;computer&quot; becomes &quot;<span class=\\\"searchmatch\\\">computa</span>&quot; and &quot;river&quot; becomes &quot;riva&quot;. Various items and actions have also been given\",\"timestamp\":\"2018-12-12T06:44:08Z\"},{\"ns\":0,\"title\":\"Brett Craig\",\"pageid\":8126599,\"size\":6573,\"wordcount\":714,\"snippet\":\"portrayed by actor, comedian and writer Peter Rowsthorn. Brett works at <span class=\\\"searchmatch\\\">Computa</span> City and is married to Kim Craig (Gina Riley) from the start of the series\",\"timestamp\":\"2018-09-11T10:22:24Z\"},{\"ns\":0,\"title\":\"Comparison of risk analysis Microsoft Excel add-ins\",\"pageid\":34277684,\"size\":38393,\"wordcount\":1213,\"snippet\":\"Inducing Rank Order Correlation Among Input Variables', Commun Statist-Simula <span class=\\\"searchmatch\\\">Computa</span> 11(3) 311-334 Lehman, D.; Groenendaal, H.; Nolder, G. (2010), Practical\",\"timestamp\":\"2018-12-07T09:23:43Z\"},{\"ns\":0,\"title\":\"List of Kath & Kim episodes\",\"pageid\":10722142,\"size\":28880,\"wordcount\":893,\"snippet\":\"Shane Warne), and Kath and Kim plan Sharon's wedding. Brett is fired from <span class=\\\"searchmatch\\\">Computa</span> City but gets a job at Krispy Kreme Doughnuts. Brett buys another apartment\",\"timestamp\":\"2018-09-12T10:04:00Z\"},{\"ns\":0,\"title\":\"Millôr Fernandes\",\"pageid\":3572882,\"size\":7355,\"wordcount\":741,\"snippet\":\"país (Editora do Autor) 1965 – Pigmaleoa (Brasiliense) 1972 – <span class=\\\"searchmatch\\\">Computa</span>, computador, <span class=\\\"searchmatch\\\">computa</span> (Nórdica) 1977 – É... (L&amp;PM) 1978 – A história é uma istória\",\"timestamp\":\"2018-11-08T01:45:51Z\"}]}}",
            "In 2004 Computas AS was split into two: Computas, and Computas Technology",
            "xgæwikhænzmwpxlwlheæwmhwlixgwzexllløxkzafxmzazhfinmxllixgwxlwbgwwlixgwzexllløxkzafxmzazhfinmxllixgwxlwpxlwliebmwbgmhwmphwlixgwzexllløxkzafxmzazhfinmxllixgwxgæwlixgwzexllløxkzafxmzazhfinmxllixgwmøzagheh rwbgwwlixgwzexllløxkzafxmzazhfinmxllixgwmøzagheh rwpxlwføk øæwpbma",
            false)]
        public async Task WhenSearchingForQuery_ShouldDisplaySearchResult_AndEncryptedSnippet(string query, int shift, string json, string partOfSnippet, string encryptedSnippet, bool decrypt)
        {
            var options = new CommandLineOptions
            {
                Shift = shift,
                Query = query,
                Decrypt = decrypt
            };

            A.CallTo(() =>
                _client.SearchAsync(query))
                .Returns(Task.FromResult(json));

            await _runner.Run(options, _writeLine);

            A.CallTo(() => _writeLine($"Searching for { query }...")).MustHaveHappened()
                .Then(A.CallTo(() => _writeLine(A<string>.That.Contains(partOfSnippet))).MustHaveHappened())
                .Then(A.CallTo(() => _writeLine("Encrypted:")).MustHaveHappened())
                .Then(A.CallTo(() => _writeLine(encryptedSnippet)).MustHaveHappened());
        }
    }
}
