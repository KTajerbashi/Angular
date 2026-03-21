interface IBaseTree<T> {
  children: T[];
  title: string;
  id: number;
  parentId?: number | null;
}
