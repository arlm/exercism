export function isPangram(text: string): boolean {
  const charArray= text
                  .toUpperCase()
                  .split('')
                  .filter(char => char >= 'A' && char <= 'Z');
                  
  const set = new Set(charArray);
  return set.size == 26;
}
