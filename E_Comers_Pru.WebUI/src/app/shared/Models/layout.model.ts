export interface IMenuItem {
  id?: number;
  label?: any;
  icon?: string;
  isCollapsed?: any;
  link?: string;
  subItems?: any;
  isTitle?: boolean;
  // idsPermissions: string[];
  badge?: any;
  parentId?: number;
  isLayout?: boolean;
}
