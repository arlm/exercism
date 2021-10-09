export class CustomSet<TElement> {
  private data?: TElement[]

  constructor(array?: TElement[] ) {
    if (array) {
    this.data = Array.from(array);
    }
  }

  empty(): boolean {
    return !this.data || this.data?.length == 0;
  }

  contains(element: TElement): boolean {
    return this.data != null && this.data.includes(element);
  }

  add(element: TElement): CustomSet<TElement> {
    this.data ??= new Array<TElement>();
    this.data.push(element);

    return new CustomSet(this.data!);
  }

  subset(other: CustomSet<TElement>): boolean {
    if (this.empty()) {
      return true;
    }

    if (other.empty()) {
      return false;
    }

    for (const item of this.data!) {
      if (!other.data!.includes(item)) {
        return false;
      }
    }

    return true;
  }
  
  disjoint(other: CustomSet<TElement>): boolean {
    if (this.empty() || other.empty()) {
      return true;
    }

    for (const item of this.data!) {
      if (other.data!.includes(item)) {
        return false;
      }
    }

    return true;
  }

  eql(other: CustomSet<TElement>): boolean {
    if (this.empty() && other.empty()) {
      return true;
    }

    if (this.empty() || other.empty()) {
      return false;
    }

    for (const item of this.data!) {
      if (!other.data!.includes(item)) {
        return false;
      }
    }

    return true;
  }

  union(other: CustomSet<TElement>): CustomSet<TElement> {
    const otherData = other.data ?? new Array<TElement>();

    if (this.empty()) {
    const otherData = other.data ?? new Array<TElement>();
      return new CustomSet<TElement>(otherData);
    }

    return new CustomSet(this.data!.concat(otherData));
  }

  intersection(other: CustomSet<TElement>): CustomSet<TElement> {
    if (this.empty() || other.empty()) {
      return new CustomSet<TElement>();
    }

    const data = this.data!.filter(item => other.data!.includes(item));

    return new CustomSet(data);
  }

  difference(other: CustomSet<TElement>): CustomSet<TElement> {
    if (this.empty()) {
      return new CustomSet<TElement>();
    }

    if (other.empty()) {
      return new CustomSet<TElement>(this.data!);
    }


    const data = this.data!.filter(item => !other.data!.includes(item));

    return new CustomSet(data);
  }
}
