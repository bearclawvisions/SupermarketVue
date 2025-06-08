import {UserRoles} from "@/enums/UserRoles.ts";

export interface RegisterModel {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
  terms: boolean;
}

export interface LoginModel {
  email: string;
  password: string;
}

export interface Portrait {
  id: string;
  name: string;
  role: string;
  photo: string;
}

export interface BlueCardInfo {
  title: string;
  body: string;
}

export interface MenuItemConfig {
  id: string;
  label: string;
  icon?: string;
  route?: string;
  url?: string;
  items?: MenuItemConfig[];
  roles: UserRoles[];
}

export interface UserModel {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  emailConfirmed: boolean;
  createdOn: Date;
  lastLogin: Date;
  roles: UserRoles[];
}