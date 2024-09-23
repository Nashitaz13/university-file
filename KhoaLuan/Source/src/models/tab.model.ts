export class Tab {
  Root: any;
  Title: string;
  TabIcon: string;
  Params: any;

  constructor(root: any, title: string, tabIcon?: string, params?: any){
    this.Root = root;
    this.Title = title;
    this.TabIcon = tabIcon || "";
    this.Params = params;
  }
}