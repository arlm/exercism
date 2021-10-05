export class SimpleCipher {
  private _key: number[];

  public constructor(key?: string) {
    const initialKey = key ?? this.generateKey();
    this._key = initialKey.split("").map(char => char.charCodeAt(0));
  }

  public generateKey(): string {
    return this.randomLetter(100);
  }

  private randomLetter(count: number): string { 
    var result = "";
    
    for (let index = 0; index < count; index++){
      result += String.fromCharCode(this.random(97, 123));
    }

    return result;
  }

  private random(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min) + min);
  }

  public encode(cleartext: string): string {
    var cypher = "";

    for (let index = 0; index < cleartext.length; index++) {
      const keyLetter = this._key[index % this._key.length];
      const textLetter = cleartext.charCodeAt(index);
      cypher += String.fromCharCode(97 + (keyLetter + textLetter) % 97 % 26);
    }

    return cypher;
  }

  public decode(cypher: string): string {
    var cleartext = "";

    for (let index = 0; index < cypher.length; index++) {
      const keyLetter = this._key[index % this._key.length];
      const cypherLetter = cypher.charCodeAt(index);
      cleartext += String.fromCharCode(97 + (26 + cypherLetter - keyLetter) % 26);
    }

    return cleartext;
  }

  public get key(): string {
    return String.fromCharCode(...this._key);
  }
}
