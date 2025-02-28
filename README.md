# Initial State

## Notes

### What is this?

I am using this as a memory exercise and to increase my knowldege of accounting. While I have no immediate plans to turn this into a viable product, I do intend on making this good enough for my personal use. We will see how far it gets from there.

### My background

As I know IT first and accounting second, I tend to think in bit sooner than cents. When approaching this problem, I want to take this in layers, similar to the OSI model. While all the layers work cohesively, the also allow for demarcations, in case you need to reason something out. In accounting, your reasoning is usually money based (put the funds in the wrong account, paid it too soon / too late) and we need to make this central to out segregations.

Layer 1: General Journal. (Take an account (drill to the n-th level. Do not summarize at any level) and have one or more credits and one or more debits. They must balance.)

Layer 2: Account Buckets (Take an account's sub level, such as interest accrued, and summarize into a bucket. In the case of the master account, the terminology is still bucket)

Layer 3: Accounts (This is all account buckets pulled into one account. Note: As layer 2 and 3 can work hand in hand, this is more of a concept layer. GL -> Cash -> Deposit Accounts -> Transactions. )

Layer 4: Balance Sheet / Income Statement / Cash Flow Statement

Layer 5: Projections, Maturity, Budgeting, Ratios

### Logging

When we talk in layers, what we did not address is how to integrate into that. At the end of the day, the success is the entry into layer 1--the general journal. But what if, upon failure, we still make the entry and keep it for logging purposes? What if, we have a transaction that is an estimate and we have to put it into a final amount? We can keep it all like this, and invalidate the estimate upon the final amount.

My reasoning is purely logging. While we are not doing a blockchain, we are taking the accounting concept of a general journal and memorializing it in a digital way. When we cut days or times, the estimates have to stay. Therefore, why do the SQL thing and remove them? We could make a real error like that.

### Integrations

Like any accounting software, the true power is when you integrate it with things. We have Credits / Debits, balanced, going into accounts. With software moving those items in and out, what you are doing in essence is automating your books. You always need the general journal, but now your work becomes assuring items are going in correctly.

If we are logging, we can see when an integration is working as designed or is being exploited. We can see the successes and failures, and then show in an immutable way what actions a third party took.

### Sheets

I think the proper terminology is "cut over" to another day, but in my terminology I like to think of it as taking a batch of journal entries and staple them, like you would a collection of sheets of paper. This isn't tied to a time period, since we want them to become immutable rather quickly.

### Cut Over

When you are finalizing a time period (i.e. a year) you tend to make some final entries to perform proper accruals or fix errors discovered. These need to be done in the past, as sometimes the entries cannot be made until things are known, and sometimes errors are not discovered.

### Slices

When you have a large amount of activity and you want to ensure your activity can occur, you need to have multiple copies of the transactions in order for you to be resilient against loss of connectivity, loss of storage, etc. For this, you also need to designate who is master on writes and who has copies on read. This is a concept I'm calling slices.

All slices should have the complete copy of the general journal. This will work if the transaction details are textual, but if photos are put into the general journal, this will balloon in size. We need to have addenda be optional for replication.

A slice can be designated as read only (like a report writer), read/write for a subset of the data (and the other slices are aware where to send for authority) and finally, a backup for the slices in the case they do not respond in time. We need to have a machanism that does livliness checks on writeable instances, and we need to setup a self healing process when they come back online. (Since we do not delete, the process should be to stack the Sheets accordingly and in the proper order. But what do we do if we have sheets beyond cut-over? At what point is something too old to merge?)

## Encryption

This should be a solved problem. Since we do not have to think about a fixed width, there are some expertly made encryption routines that combat replay attacks, that perform hash checking for verification, and can provide a one-way protection against account numbers being dumped en masse.

## Thinking about this in the bigger picture

Perhaps the biggest feat will be the slices.
