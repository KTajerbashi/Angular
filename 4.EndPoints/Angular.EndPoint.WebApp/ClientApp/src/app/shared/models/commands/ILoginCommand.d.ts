interface ILoginCommand {
  userName: string;
  password: string;
  returnUrl: string;
  isRemember: boolean;
}
