export class TodoItemNode {
    children: TodoItemNode[];
    item: string;
    Title: string;
  }
  
  /** Flat to-do item node with expandable and level information */
  export class TodoItemFlatNode {
    item: string;
    Title: string;
    level: number;
    expandable: boolean;
  }