export interface IResponseVM<T> {
  result: boolean;
  isError: boolean;
  message: string;
  element: T;
}
