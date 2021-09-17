## Introduction

Revenue Recognition

A company that sells three kinds of products: word processors, databases, and spreadsheets
When you sign a contract for a word processor you can book 
If it's a spreadsheet, you can book one-third ay, one-third in sixty days, and one-third in ninety days. 
If it's a database, you can book one-third today, the-third in thirty days, and one-third in sixty day

## Content
- DataAccess - Layer for Entities
- TableModel - implementation of table module organization domain logic
- TransactionScript - implementation of transaction organization domain logic

## Plans

It should be implementation in Domain Model too.

## Pros and cons
### Transaction Script 
A Transaction Script (110) offers several advantages: <br/>
- It’s a simple procedural model that most developers understand.
- It works well with a simple data source layer using Row Data Gateway
(152) or Table Data Gateway (144).
- It’s obvious how to set the transaction boundaries: Start with opening a
transaction and end with closing it. It’s easy for tools to do this behind the
scenes

There are also plenty of disadvantages, which tend to appear as <br/>
- The complexity of the domain logic increases. 
- Duplicated code as several transactions need to do similar things. </br>
Some of this can be dealt with by
factoring out common subroutines, but even so much of the duplication is
tricky to remove and harder to spot.

### Table Module
Domain Model (116) has one instance of contract for each
contract in the database whereas a Table Module (125) has only one instance.

- is designed to work with a Record Set
- Organizing the domain logic around tables rather than straight procedures provides more structure and makes it easier to find and remove duplication
- how it fits into the rest of the architecture. Many GUI environments are built to work on the results of a SQL query organized in a Record Set.

Disadvantages:
- you can’t use a number of the techniques that a Domain Model (116) uses for finer grained structure of the logic, such as inheritance, strategies, and other OO patterns


### Domain Model
A model of our domain which, at least on a first approximation.
- organized primarily around the nouns in the domain
- theessence of the paradigm shift that object-oriented people talk about so much.
- Rather than one routine having all the logic for a user action, each object takes
a part of the logic that’s relevant to it.
- once you’ve gotten
used to things, there are many techniques that allow you to handle increasingly
complex logic in a well-organized way
<br/>
The cost of a Domain Model
- come from the complexity of using it and the complexity of your data source layer. 
- It takes time for people new to rich object models to get used to a rich Domain Model