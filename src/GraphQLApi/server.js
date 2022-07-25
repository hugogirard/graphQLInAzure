const { ApolloServer, gql } = require('apollo-server');

const port = process.env.PORT || 4000;

const typeDefs = gql`
type Query {
  sessions:[Session]
}
type Session {
  id: ID!
  title: String!,
  description:String,
  startsAt:String,
  endsAt:String,
  room:String,
  day:String,
  format: String,
  track:String,
  level:String
}`

const server = new ApolloServer({ typeDefs });

server.listen(port)
      .then(({ url }) => {
        console.log(`graphQL running at ${url}`);
      });