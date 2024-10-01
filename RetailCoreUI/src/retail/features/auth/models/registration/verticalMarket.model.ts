import { TreeNode } from 'primeng/api';

export interface IVerticalMarket {
  id: string;
  projectVerticalName: string;
  subProjectVerticalList: SubProjectVertical[];
}
export interface SubProjectVertical {
  id: string;
  subProjectVerticalName: string;
}
