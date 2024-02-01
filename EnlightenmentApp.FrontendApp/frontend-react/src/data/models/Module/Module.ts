import Tag from "../Tag/Tag";
import Section from "../Section/Section";
import ModuleReview from "../ModuleReview/ModuleReview";

export default class Module {
  id: number = 0;
  title: string = "";
  author: string = "";
  rating: number = 0;
  cost: number = 0;
  summary: string = "";
  reviews: ModuleReview[] = [];
  tags: Tag[] = [];
  imageSrc: string = "";
  sections: Section[] = [];
  isCompleted: boolean = false;
}
