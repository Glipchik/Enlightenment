import { TagType } from "../enums/TagType";

export default interface Tag {
  id: number;
  type: TagType;
  value: string;
  metaData: string;
  isBasic: boolean;
}
