enum AllergyList {
  none          = 0,      // 0
  eggs          = 1 << 0, // 1
  peanuts       = 1 << 1, // 2
  shellfish     = 1 << 2, // 4
  strawberries  = 1 << 3, // 8
  tomatoes      = 1 << 4, // 16
  chocolate     = 1 << 5, // 32
  pollen        = 1 << 6, // 64
  cats          = 1 << 7, // 128
}

type Allergy = keyof typeof AllergyList;

export class Allergies {
  private readonly allergies: AllergyList

  constructor(allergenIndex: number) {
    this.allergies = <AllergyList>allergenIndex
  }

  public list(): string[] {
    const bits = this.allergyBits
    return bits
      .map(bit => this.has(bit)? AllergyList[bit] : '')
      .filter(text => text);
  }

  private has(allergy: AllergyList): boolean {
    return (this.allergies & allergy) === allergy;
  }

  private get allergyBits(): number[] {
    return Object.keys(AllergyList).map(Number).filter(Boolean);
  }

  public allergicTo(allergen: Allergy): boolean {
    return this.has(AllergyList[allergen]);
  }
}
