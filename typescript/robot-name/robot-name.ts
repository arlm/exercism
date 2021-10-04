export class Robot {
  private static readonly names = new Set<string>();
  private _name:string = "";

  constructor() {
    this.generateName();
  }
  
  private generateName() {
    var name = "";

    while (name == "" || Robot.names.has(name)) {
      name = this.randomLetter(2) + this.randomNumber(3);
    }
    
    Robot.names.add(name);
    this._name = name;
  }

  private randomLetter(count: number): string { 
    var result = "";
    
    for (let index = 0; index < count; index++){
      result += String.fromCharCode(this.random(65, 91));
    }

    return result;
  }

  private randomNumber(count: number): string {
    var result = "";

    for (let index = 0; index < count; index++){
      result += String.fromCharCode(this.random(48, 58));
    }

    return result;
  }

  private random(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min) + min);
  }

  public get name(): string {
    return this._name;
  }

  public resetName(): void {
    this.generateName();
  }

  public static releaseNames(): void {
    Robot.names.clear();
  }
}
