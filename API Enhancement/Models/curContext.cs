using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Enhancement.Models
{
    public partial class curContext : DbContext
    {
        public curContext()
        {
        }

        public curContext(DbContextOptions<curContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cur> Curs { get; set; } = null!;
        public virtual DbSet<Output> Outputs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=cur;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cur>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("cur");

                entity.HasIndex(e => e.Pk, "IX_cur");

                entity.Property(e => e.Pk)
                    .ValueGeneratedNever()
                    .HasColumnName("pk");

                entity.Property(e => e.BillPayerAccountId)
                    .HasMaxLength(4000)
                    .HasColumnName("bill_PayerAccountId");

                entity.Property(e => e.LineItemUnblendedCost)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UnblendedCost");

                entity.Property(e => e.LineItemUnblendedRate)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UnblendedRate");

                entity.Property(e => e.LineItemUsageAccountId)
                    .HasMaxLength(50)
                    .HasColumnName("lineItem_UsageAccountId");

                entity.Property(e => e.LineItemUsageAmount)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageAmount");

                entity.Property(e => e.LineItemUsageEndDate)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageEndDate");

                entity.Property(e => e.LineItemUsageStartDate)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageStartDate");

                entity.Property(e => e.ProductProductName)
                    .HasMaxLength(4000)
                    .HasColumnName("product_ProductName");
            });

            modelBuilder.Entity<Output>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.ToTable("output");

                entity.Property(e => e.Pk)
                    .ValueGeneratedNever()
                    .HasColumnName("pk");

                entity.Property(e => e.BillBillType)
                    .HasMaxLength(4000)
                    .HasColumnName("bill_BillType");

                entity.Property(e => e.BillBillingEntity)
                    .HasMaxLength(4000)
                    .HasColumnName("bill_BillingEntity");

                entity.Property(e => e.BillBillingPeriodStartDate)
                    .HasMaxLength(4000)
                    .HasColumnName("bill_BillingPeriodStartDate");

                entity.Property(e => e.BillInvoiceId)
                    .HasMaxLength(4000)
                    .HasColumnName("bill_InvoiceId");

                entity.Property(e => e.BillPayerAccountId)
                    .HasMaxLength(4000)
                    .HasColumnName("bill_PayerAccountId");

                entity.Property(e => e.IdentityLineItemId)
                    .HasMaxLength(4000)
                    .HasColumnName("identity_LineItemId");

                entity.Property(e => e.LineItemAvailabilityZone)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_AvailabilityZone");

                entity.Property(e => e.LineItemLineItemDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_LineItemDescription");

                entity.Property(e => e.LineItemLineItemType)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_LineItemType");

                entity.Property(e => e.LineItemNormalizationFactor)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_NormalizationFactor");

                entity.Property(e => e.LineItemNormalizedUsageAmount)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_NormalizedUsageAmount");

                entity.Property(e => e.LineItemOperation)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_Operation");

                entity.Property(e => e.LineItemResourceId)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_ResourceId");

                entity.Property(e => e.LineItemUnblendedCost)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UnblendedCost");

                entity.Property(e => e.LineItemUnblendedRate)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UnblendedRate");

                entity.Property(e => e.LineItemUsageAccountId)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageAccountId");

                entity.Property(e => e.LineItemUsageAmount)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageAmount");

                entity.Property(e => e.LineItemUsageEndDate)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageEndDate");

                entity.Property(e => e.LineItemUsageStartDate)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageStartDate");

                entity.Property(e => e.LineItemUsageType)
                    .HasMaxLength(4000)
                    .HasColumnName("lineItem_UsageType");

                entity.Property(e => e.PricingLeaseContractLength)
                    .HasMaxLength(4000)
                    .HasColumnName("pricing_LeaseContractLength");

                entity.Property(e => e.PricingOfferingClass)
                    .HasMaxLength(4000)
                    .HasColumnName("pricing_OfferingClass");

                entity.Property(e => e.PricingPublicOnDemandRate)
                    .HasMaxLength(4000)
                    .HasColumnName("pricing_publicOnDemandRate");

                entity.Property(e => e.PricingPurchaseOption)
                    .HasMaxLength(4000)
                    .HasColumnName("pricing_PurchaseOption");

                entity.Property(e => e.PricingTerm)
                    .HasMaxLength(4000)
                    .HasColumnName("pricing_term");

                entity.Property(e => e.ProductCacheEngine)
                    .HasMaxLength(4000)
                    .HasColumnName("product_cacheEngine");

                entity.Property(e => e.ProductDatabaseEdition)
                    .HasMaxLength(4000)
                    .HasColumnName("product_databaseEdition");

                entity.Property(e => e.ProductDatabaseEngine)
                    .HasMaxLength(4000)
                    .HasColumnName("product_databaseEngine");

                entity.Property(e => e.ProductDeploymentOption)
                    .HasMaxLength(4000)
                    .HasColumnName("product_deploymentOption");

                entity.Property(e => e.ProductInstanceType)
                    .HasMaxLength(4000)
                    .HasColumnName("product_instanceType");

                entity.Property(e => e.ProductInstanceTypeFamily)
                    .HasMaxLength(4000)
                    .HasColumnName("product_instanceTypeFamily");

                entity.Property(e => e.ProductLicenseModel)
                    .HasMaxLength(4000)
                    .HasColumnName("product_licenseModel");

                entity.Property(e => e.ProductLocation)
                    .HasMaxLength(4000)
                    .HasColumnName("product_location");

                entity.Property(e => e.ProductOperatingSystem)
                    .HasMaxLength(4000)
                    .HasColumnName("product_operatingSystem");

                entity.Property(e => e.ProductProductName)
                    .HasMaxLength(4000)
                    .HasColumnName("product_ProductName");

                entity.Property(e => e.ProductRegion)
                    .HasMaxLength(4000)
                    .HasColumnName("product_region");

                entity.Property(e => e.ProductTenancy)
                    .HasMaxLength(4000)
                    .HasColumnName("product_tenancy");

                entity.Property(e => e.ReservationAmortizedUpfrontCostForUsage)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_AmortizedUpfrontCostForUsage");

                entity.Property(e => e.ReservationAmortizedUpfrontFeeForBillingPeriod)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_AmortizedUpfrontFeeForBillingPeriod");

                entity.Property(e => e.ReservationEffectiveCost)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_EffectiveCost");

                entity.Property(e => e.ReservationEndTime)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_EndTime");

                entity.Property(e => e.ReservationModificationStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_ModificationStatus");

                entity.Property(e => e.ReservationNumberOfReservations)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_NumberOfReservations");

                entity.Property(e => e.ReservationRecurringFeeForUsage)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_RecurringFeeForUsage");

                entity.Property(e => e.ReservationReservationArn)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_ReservationARN");

                entity.Property(e => e.ReservationStartTime)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_StartTime");

                entity.Property(e => e.ReservationSubscriptionId)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_SubscriptionId");

                entity.Property(e => e.ReservationTotalReservedUnits)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_TotalReservedUnits");

                entity.Property(e => e.ReservationUnusedAmortizedUpfrontFeeForBillingPeriod)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_UnusedAmortizedUpfrontFeeForBillingPeriod");

                entity.Property(e => e.ReservationUnusedNormalizedUnitQuantity)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_UnusedNormalizedUnitQuantity");

                entity.Property(e => e.ReservationUnusedQuantity)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_UnusedQuantity");

                entity.Property(e => e.ReservationUnusedRecurringFee)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_UnusedRecurringFee");

                entity.Property(e => e.ReservationUpfrontValue)
                    .HasMaxLength(4000)
                    .HasColumnName("reservation_UpfrontValue");

                entity.Property(e => e.ResourceTagsAwsCreatedBy)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_aws_createdBy");

                entity.Property(e => e.ResourceTagsUserAutotag)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_autotag");

                entity.Property(e => e.ResourceTagsUserBilling)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_Billing");

                entity.Property(e => e.ResourceTagsUserEbs)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_EBS");

                entity.Property(e => e.ResourceTagsUserEc2)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_EC2");

                entity.Property(e => e.ResourceTagsUserEnvironment)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_Environment");

                entity.Property(e => e.ResourceTagsUserExt01)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_ext01");

                entity.Property(e => e.ResourceTagsUserName)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_Name");

                entity.Property(e => e.ResourceTagsUserProject)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_Project");

                entity.Property(e => e.ResourceTagsUserRds)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_RDS");

                entity.Property(e => e.ResourceTagsUserSite)
                    .HasMaxLength(4000)
                    .HasColumnName("resourceTags_user_Site");

                entity.Property(e => e.SavingsPlanAmortizedUpfrontCommitmentForBillingPeriod)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_AmortizedUpfrontCommitmentForBillingPeriod");

                entity.Property(e => e.SavingsPlanEndTime)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_EndTime");

                entity.Property(e => e.SavingsPlanOfferingType)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_OfferingType");

                entity.Property(e => e.SavingsPlanPaymentOption)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_PaymentOption");

                entity.Property(e => e.SavingsPlanPurchaseTerm)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_PurchaseTerm");

                entity.Property(e => e.SavingsPlanRecurringCommitmentForBillingPeriod)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_RecurringCommitmentForBillingPeriod");

                entity.Property(e => e.SavingsPlanRegion)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_Region");

                entity.Property(e => e.SavingsPlanSavingsPlanArn)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_SavingsPlanARN");

                entity.Property(e => e.SavingsPlanSavingsPlanEffectiveCost)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_SavingsPlanEffectiveCost");

                entity.Property(e => e.SavingsPlanSavingsPlanRate)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_SavingsPlanRate");

                entity.Property(e => e.SavingsPlanStartTime)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_StartTime");

                entity.Property(e => e.SavingsPlanTotalCommitmentToDate)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_TotalCommitmentToDate");

                entity.Property(e => e.SavingsPlanUsedCommitment)
                    .HasMaxLength(4000)
                    .HasColumnName("savingsPlan_UsedCommitment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
