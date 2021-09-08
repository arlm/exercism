//
// This is only a SKELETON file for the 'Word Count' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const countWords = (text) => {
  var words = text.split(/[^a-zA-Z0-9']+/).filter(x => x);
  var result = {};
  console.log(words);
  for (const word of words) {
    const startsWithQuote = word.startsWith('"') || word.startsWith("'");
    const endsWithQuote = word.endsWith('"') || word.endsWith("'");
    
    var smallWord = word.substring( startsWithQuote ? 1 : 0, endsWithQuote ? word.length - 1 : word.length).toLowerCase();
    
    result[smallWord] ??= 0;  
    result[smallWord] += 1;  
  }

  return result;
}
