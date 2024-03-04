import React, { SyntheticEvent, useState } from "react";
import { Post } from "../../../app/models/post";
import { Button, Item, Segment } from "semantic-ui-react";

interface Props {
  posts: Post[];
  selectPost: (id: string) => void;
  deletePost: (id: string) => void;
  submitting: boolean;
}

export default function PostList({
  posts,
  selectPost,
  deletePost,
  submitting,
}: Props) {
  const [target, setTarget] = useState("");

  function handlePostDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
    setTarget(e.currentTarget.name)
    deletePost(id);
  }

  return (
    <Segment>
      <Item.Group divided>
        {posts.map((post) => (
          <Item key={post.id}>
            <Item.Content>
              <Item.Header as="a">{post.title}</Item.Header>
              <Item.Meta>{post.date}</Item.Meta>
              <Item.Description>
                <div>{post.description}</div>
              </Item.Description>
              <Item.Extra>
                <Button
                  onClick={() => selectPost(post.id)}
                  floated="right"
                  content="View"
                  color="blue"
                />
                <Button
                  name={post.id}
                  loading={submitting && target === post.id}
                  onClick={(e) => handlePostDelete(e, post.id)}
                  floated="right"
                  content="Delete"
                  color="red"
                />
              </Item.Extra>
            </Item.Content>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
