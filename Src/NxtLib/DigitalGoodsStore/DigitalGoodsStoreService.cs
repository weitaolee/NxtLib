﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NxtLib.Internal;
using NxtLib.Local;

namespace NxtLib.DigitalGoodsStore
{
    public class DigitalGoodsStoreService : BaseService, IDigitalGoodsStoreService
    {
        public DigitalGoodsStoreService(string baseAddress = Constants.DefaultNxtUrl)
            : base(baseAddress)
        {
        }

        public async Task<TransactionCreatedReply> Delisting(ulong goodsId, CreateTransactionParameters parameters)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Goods, goodsId.ToString()}};
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsDelisting", queryParameters);
        }

        public async Task<TransactionCreatedReply> Delivery(ulong purchaseId, CreateTransactionParameters parameters,
            Amount discount = null, string goodsToEncrypt = null, bool? goodsIsText = null, string goodsData = null,
            BinaryHexString goodsNonce = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Purchase, purchaseId.ToString()}};
            parameters.AppendToQueryParameters(queryParameters);
            if (discount != null)
            {
                queryParameters.AddIfHasValue(Parameters.DiscountNqt, discount.Nqt);
            }
            queryParameters.AddIfHasValue(Parameters.GoodsToEncrypt, goodsToEncrypt);
            queryParameters.AddIfHasValue(Parameters.GoodsIsText, goodsIsText);
            queryParameters.AddIfHasValue(Parameters.GoodsData, goodsData);
            if (goodsNonce != null)
            {
                queryParameters.AddIfHasValue(Parameters.GoodsNonce, goodsNonce.ToHexString());
            }
            return await Post<TransactionCreatedReply>("dgsDelivery", queryParameters);
        }

        public async Task<TransactionCreatedReply> Feedback(ulong purchaseId, CreateTransactionParameters parameters)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Purchase, purchaseId.ToString()}};
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsFeedback", queryParameters);
        }

        public async Task<PurchasesReply> GetExpiredPurchases(Account seller, int? firstIndex = null,
            int? lastIndex = null, ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Seller, seller.AccountId.ToString()}};
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Post<PurchasesReply>("getExpiredPurchases", queryParameters);
        }

        public async Task<GoodReply> GetGood(ulong goodsId, bool? includeCounts = null, ulong? requireBlock = null,
            ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Goods, goodsId.ToString()}};
            queryParameters.AddIfHasValue(Parameters.IncludeCounts, includeCounts);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<GoodReply>("getDGSGood", queryParameters);
        }

        public async Task<GoodsReply> GetGoods(Account seller = null, int? firstIndex = null, int? lastIndex = null,
            bool? inStockOnly = null, bool? hideDelisted = null, bool? includeCounts = null, ulong? requireBlock = null,
            ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.Seller, seller);
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.InStockOnly, inStockOnly);
            queryParameters.AddIfHasValue(Parameters.HideDelisted, hideDelisted);
            queryParameters.AddIfHasValue(Parameters.IncludeCounts, includeCounts);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<GoodsReply>("getDGSGoods", queryParameters);
        }

        public async Task<GoodsCountReply> GetGoodsCount(Account seller = null, bool? inStockOnly = null,
            ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.Seller, seller);
            queryParameters.AddIfHasValue(Parameters.InStockOnly, inStockOnly);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<GoodsCountReply>("getDGSGoodsCount", queryParameters);
        }

        public async Task<PuchaseCountReply> GetGoodsPurchaseCount(ulong goodsId, bool? withPublicFeedbacksOnly = null,
            bool? completed = null, ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Goods, goodsId.ToString()}};
            queryParameters.AddIfHasValue(Parameters.WithPublicFeedbacksOnly, withPublicFeedbacksOnly);
            queryParameters.AddIfHasValue(Parameters.Completed, completed);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<PuchaseCountReply>("getDGSGoodsPurchaseCount", queryParameters);
        }

        public async Task<PurchasesReply> GetGoodsPurchases(ulong goodsId, Account buyer = null, int? firstIndex = null,
            int? lastIndex = null, bool? withPublicFeedbacksOnly = null, bool? completed = null,
            ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Goods, goodsId.ToString()}};
            queryParameters.AddIfHasValue(Parameters.Buyer, buyer);
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.WithPublicFeedbacksOnly, withPublicFeedbacksOnly);
            queryParameters.AddIfHasValue(Parameters.Completed, completed);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<PurchasesReply>("getDGSGoodsPurchases", queryParameters);
        }

        public async Task<PurchasesReply> GetPendingPurchases(Account seller, int? firstIndex = null,
            int? lastIndex = null, ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Seller, seller.AccountId.ToString()}};
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<PurchasesReply>("getDGSPendingPurchases", queryParameters);
        }

        public async Task<PurchaseReply> GetPurchase(ulong purchaseId, string secretPhrase = null,
            BinaryHexString sharedKey = null, ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.Purchase, purchaseId.ToString()}};
            queryParameters.AddIfHasValue(Parameters.SecretPhrase, secretPhrase);
            queryParameters.AddIfHasValue(Parameters.SharedKey, sharedKey);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<PurchaseReply>("getDGSPurchase", queryParameters);
        }

        public async Task<PuchaseCountReply> GetPurchaseCount(Account seller = null, Account buyer = null,
            bool? withPublicFeedbacksOnly = null, bool? completed = null, ulong? requireBlock = null,
            ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.Seller, seller);
            queryParameters.AddIfHasValue(Parameters.Buyer, buyer);
            queryParameters.AddIfHasValue(Parameters.WithPublicFeedbacksOnly, withPublicFeedbacksOnly);
            queryParameters.AddIfHasValue(Parameters.Completed, completed);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<PuchaseCountReply>("getDGSPurchaseCount", queryParameters);
        }

        public async Task<PurchasesReply> GetPurchases(Account seller = null, Account buyer = null,
            int? firstIndex = null, int? lastIndex = null, bool? withPublicFeedbacksOnly = null, bool? completed = null,
            ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.Seller, seller);
            queryParameters.AddIfHasValue(Parameters.Buyer, buyer);
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.WithPublicFeedbacksOnly, withPublicFeedbacksOnly);
            queryParameters.AddIfHasValue(Parameters.Completed, completed);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<PurchasesReply>("getDGSPurchases", queryParameters);
        }

        public async Task<TagCountReply> GetTagCount(bool? inStockOnly = null, ulong? requireBlock = null,
            ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.InStockOnly, inStockOnly);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<TagCountReply>("getDGSTagCount", queryParameters);
        }

        public async Task<TagsReply> GetTags(bool? inStockOnly = null, int? firstIndex = null, int? lastIndex = null,
            ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.InStockOnly, inStockOnly);
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<TagsReply>("getDGSTags", queryParameters);
        }

        public async Task<TagsReply> GetTagsLike(string tagPrefix, bool? inStockOnly = null, int? firstIndex = null,
            int? lastIndex = null, ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string> {{Parameters.TagPrefix, tagPrefix}};
            queryParameters.AddIfHasValue(Parameters.InStockOnly, inStockOnly);
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<TagsReply>("getDGSTagsLike", queryParameters);
        }

        public async Task<TransactionCreatedReply> Listing(string name, string description, int quantity, Amount price,
            CreateTransactionParameters parameters, string tags = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {Parameters.Name, name},
                {Parameters.Description, description},
                {Parameters.Quantity, quantity.ToString()},
                {Parameters.PriceNqt, price.Nqt.ToString()}
            };
            queryParameters.AddIfHasValue(Parameters.Tags, tags);
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsListing", queryParameters);
        }

        public async Task<TransactionCreatedReply> PriceChange(ulong goodsId, Amount price,
            CreateTransactionParameters parameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {Parameters.Goods, goodsId.ToString()},
                {Parameters.PriceNqt, price.Nqt.ToString()}
            };
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsPriceChange", queryParameters);
        }

        public async Task<TransactionCreatedReply> Purchase(ulong goodsId, Amount price, int quantity,
            DateTime deliveryDeadlineTimestamp, CreateTransactionParameters parameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {Parameters.Goods, goodsId.ToString()},
                {Parameters.PriceNqt, price.Nqt.ToString()},
                {Parameters.Quantity, quantity.ToString()}
            };
            queryParameters.AddIfHasValue(Parameters.DeliveryDeadlineTimestamp, deliveryDeadlineTimestamp);
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsPurchase", queryParameters);
        }

        public async Task<TransactionCreatedReply> QuantityChange(ulong goodsId, int deltaQuantity,
            CreateTransactionParameters parameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {Parameters.Goods, goodsId.ToString()},
                {Parameters.DeltaQuantity, deltaQuantity.ToString()}
            };
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsQuantityChange", queryParameters);
        }

        public async Task<TransactionCreatedReply> Refund(ulong purchaseId, Amount refund,
            CreateTransactionParameters parameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {Parameters.Purchase, purchaseId.ToString()},
                {Parameters.RefundNqt, refund.Nqt.ToString()}
            };
            parameters.AppendToQueryParameters(queryParameters);
            return await Post<TransactionCreatedReply>("dgsRefund", queryParameters);
        }

        public async Task<GoodsReply> SearchGoods(string query = null, string tag = null, Account seller = null,
            int? firstIndex = null, int? lastIndex = null, bool? inStockOnly = null, bool? hideDelisted = null,
            bool? includeCounts = null, ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(Parameters.Query, query);
            queryParameters.AddIfHasValue(Parameters.Tag, tag);
            queryParameters.AddIfHasValue(Parameters.Seller, seller);
            queryParameters.AddIfHasValue(Parameters.FirstIndex, firstIndex);
            queryParameters.AddIfHasValue(Parameters.LastIndex, lastIndex);
            queryParameters.AddIfHasValue(Parameters.InStockOnly, inStockOnly);
            queryParameters.AddIfHasValue(Parameters.HideDelisted, hideDelisted);
            queryParameters.AddIfHasValue(Parameters.IncludeCounts, includeCounts);
            queryParameters.AddIfHasValue(Parameters.RequireBlock, requireBlock);
            queryParameters.AddIfHasValue(Parameters.RequireLastBlock, requireLastBlock);
            return await Get<GoodsReply>("searchDGSGoods", queryParameters);
        }
    }
}