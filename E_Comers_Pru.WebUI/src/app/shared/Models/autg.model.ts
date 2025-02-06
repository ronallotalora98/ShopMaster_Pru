export interface LoginRequestVM {
  username: string;
  password: string;
}

export interface LoginResponseVM {
  user: UserDto;
  roles: RolDto | null;
  token: string;
}

export interface UserDto {
  id: number;
  name: string | null;
  //Password: string | null;
  email: string | null;

}

export interface RolDto {
  id: number;
  name: string;
  code: string;
}
