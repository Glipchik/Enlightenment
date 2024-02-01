import { TagType } from "../enums/TagType";

export default class Tag {
  id: number = 0;
  type: TagType = 0;
  value: string = "";
  metaData: string = "";
  isBasic: boolean = false;
}
