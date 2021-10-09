class LinkedListItem<TElement> {
  public next: LinkedListItem<TElement> | undefined;
  public previous: LinkedListItem<TElement> | undefined;

  constructor(public readonly value: TElement) {}

  public makeOrphan() {
    this.next = undefined;
    this.previous = undefined;
  }

  public unlinkNext() {
    if (!this.next) {
      return;
    }

    this.next.previous = undefined;
    this.next = undefined;
  }

  public linkNext(next: LinkedListItem<TElement> | undefined) {
    if (this.next) {
      throw new Error("Cannot link a new next item, already contains next.");
    }

    this.next = next;

    if (next) {
      next.previous = this;
    }
  }

  public unlinkPrevious() {
    if (!this.previous) {
      return;
    }

    this.previous.next = undefined;
    this.previous = undefined;
  }

  public linkPrevious(previous: LinkedListItem<TElement> | undefined) {
    if (this.previous) {
      throw new Error("Cannot link a new next item, already contains next.");
    }

    this.previous = previous;

    if (previous) {
      previous.next = this;
    }
  }
}

export class LinkedList<TElement> {
  private head: LinkedListItem<TElement> | undefined;
  private tail: LinkedListItem<TElement> | undefined;

  public push(element: TElement) {
    if (this.tail) {
      const item = new LinkedListItem(element);
      this.tail.linkNext(item);
      this.tail = item;
    } else {
      this.head = new LinkedListItem(element);
      this.tail = this.head;
    }
  }

  public pop(): TElement {
    if (this.tail) {
      const result = this.tail.value;

      if (this.tail === this.head) {
        this.tail = undefined;
        this.head = undefined;
      } else {
        const previous = this.tail.previous;
        this.tail.unlinkPrevious();
        this.tail = previous;
      }

      return result;
    } else {
      throw new Error("The list is empty!");
    }
  }

  public shift(): TElement {
    if (this.head) {
      const result = this.head.value;

      if (this.tail === this.head) {
        this.tail = undefined;
        this.head = undefined;
      } else {
        const next = this.head.next;
        this.head.unlinkNext();
        this.head = next;
      }

      return result;
    } else {
      throw new Error("The list is empty!");
    }
  }

  public unshift(element: TElement) {
    if (this.head) {
      const item = new LinkedListItem(element);
      this.head.linkPrevious(item);
      this.head = item;
    } else {
      this.head = new LinkedListItem(element);
      this.tail = this.head;
    }
  }

  public delete(element: TElement) {
    var item = this.head;

    while (item) {
      if (item.value === element) {
        const next = item.next;
        const previous = item.previous;

        item.unlinkPrevious();
        item.unlinkNext();

        next?.linkPrevious(previous);

        if (item === this.head) {
          this.head = next;
        }

        if (item === this.tail) {
          this.tail = previous;
        }
      }

      item = item.next;
    }
  }

  public count(): number {
    let count = 0;
    var item = this.head;

    while (item) {
      count++;
      item = item.next;
    }

    return count;
  }
}
