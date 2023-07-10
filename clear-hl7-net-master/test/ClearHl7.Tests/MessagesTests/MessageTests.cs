﻿using System;
using ClearHl7.V290;
using ClearHl7.V290.Segments;
using ClearHl7.V290.Types;
using FluentAssertions;
using Xunit;

namespace ClearHl7.Tests.MessagesTests
{
    public class MessageTests
    {
        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithAllProperties_ReturnsCorrectlyInitializedFields()
        {
            IMessage expected = new Message
            {
                Segments = new ISegment[]
                {
                    new MshSegment
                    {
                        SendingApplication = new HierarchicDesignator
                        {
                            NamespaceId = "Sender 1"
                        },
                        ReceivingApplication = new HierarchicDesignator
                        {
                            NamespaceId = "Receiver 1"
                        },
                        DateTimeOfMessage = new DateTime(2020, 12, 2, 14, 45, 39)
                    },

                    new CdmSegment
                    {
                        Ordinal = 2,

                        // Repeating component, with separated values
                        ChargeCodeAlias = new CodedWithExceptions[]
                        {
                            new CodedWithExceptions
                            {
                                Identifier = "Code 1",
                                Text = "ABC"
                            },
                            new CodedWithExceptions
                            {
                                Identifier = "Code 2",
                                Text = "ZYX"
                            }
                        }
                    },

                    new In1Segment
                    {
                        Ordinal = 1,

                        SetIdIn1 = 15,
                        HealthPlanId = new CodedWithExceptions
                        {
                            Identifier = "MNO Healthcare"
                        },

                        // Component with subcomponents
                        InsuranceCompanyId = new ExtendedCompositeIdWithCheckDigit[]
                        {
                            new ExtendedCompositeIdWithCheckDigit
                            {
                                IdNumber = "736HB",
                                AssigningAuthority = new HierarchicDesignator
                                {
                                    NamespaceId = "DES1",
                                    UniversalId = "UID654",
                                    UniversalIdType = "Type 5"
                                }
                            },
                            new ExtendedCompositeIdWithCheckDigit
                            {
                                IdNumber = "AA876",
                                AssigningAuthority = new HierarchicDesignator
                                {
                                    NamespaceId = "LLL098",
                                    UniversalId = "UID123",
                                    UniversalIdType = "Type 7"
                                }
                            }
                        }
                    }
                }
            };

            IMessage actual = new Message();
            actual.FromDelimitedString($"MSH|^~\\&|Sender 1||Receiver 1||20201202144539|||||2.9{ Consts.LineTerminator }IN1|15|MNO Healthcare|736HB^^^DES1&UID654&Type 5~AA876^^^LLL098&UID123&Type 7{ Consts.LineTerminator }CDM||Code 1^ABC~Code 2^ZYX{ Consts.LineTerminator }");

            expected.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates that FromDelimitedString() returns the object instance with all properties correctly initialized when custom delimiters are used.
        /// </summary>
        [Fact]
        public void FromDelimitedString_WithCustomDelimiters_ReturnsCorrectlyInitializedFields()
        {
            IMessage expected = new Message
            {
                Segments = new ISegment[]
                {
                    new MshSegment
                    {
                        SendingApplication = new HierarchicDesignator
                        {
                            NamespaceId = "Sender 1"
                        },
                        ReceivingApplication = new HierarchicDesignator
                        {
                            NamespaceId = "Receiver 1"
                        },
                        DateTimeOfMessage = new DateTime(2020, 12, 2, 14, 45, 39)
                    },

                    new CdmSegment
                    {
                        Ordinal = 2,

                        // Repeating component, with separated values
                        ChargeCodeAlias = new CodedWithExceptions[]
                        {
                            new CodedWithExceptions
                            {
                                Identifier = "Code 1",
                                Text = "ABC"
                            },
                            new CodedWithExceptions
                            {
                                Identifier = "Code 2",
                                Text = "ZYX"
                            }
                        }
                    },

                    new In1Segment
                    {
                        Ordinal = 1,

                        SetIdIn1 = 15,
                        HealthPlanId = new CodedWithExceptions
                        {
                            Identifier = "MNO Healthcare"
                        },

                        // Component with subcomponents
                        InsuranceCompanyId = new ExtendedCompositeIdWithCheckDigit[]
                        {
                            new ExtendedCompositeIdWithCheckDigit
                            {
                                IdNumber = "736HB",
                                AssigningAuthority = new HierarchicDesignator
                                {
                                    NamespaceId = "DES1",
                                    UniversalId = "UID654",
                                    UniversalIdType = "Type 5"
                                }
                            },
                            new ExtendedCompositeIdWithCheckDigit
                            {
                                IdNumber = "AA876",
                                AssigningAuthority = new HierarchicDesignator
                                {
                                    NamespaceId = "LLL098",
                                    UniversalId = "UID123",
                                    UniversalIdType = "Type 7"
                                }
                            }
                        }
                    }
                }
            };

            IMessage actual = new Message();
            actual.FromDelimitedString($"MSH~$*\\-~Sender 1~~Receiver 1~~20201202144539~~~~~2.9{ Consts.LineTerminator }IN1~15~MNO Healthcare~736HB$$$DES1-UID654-Type 5*AA876$$$LLL09--UID123-Type 7{ Consts.LineTerminator }CDM~~Code 1$ABC*Code 2$ZYX{ Consts.LineTerminator }");

            expected.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates that ToDelimitedString() returns output with all segments populated and in order.
        /// </summary>
        [Fact]
        public void ToDelimitedString_WithThreeSegments_ReturnsCorrectMessage()
        {
            Message message = new()
            {
                Segments = new ISegment[]
                {
                    new MshSegment
                    {
                        SendingApplication = new HierarchicDesignator
                        {
                            NamespaceId = "Sender 1"
                        },
                        ReceivingApplication = new HierarchicDesignator
                        {
                            NamespaceId = "Receiver 1"
                        },
                        DateTimeOfMessage = new DateTime(2020, 12, 2, 14, 45, 39)
                    },

                    new CdmSegment
                    {
                        Ordinal = 2,

                        // Repeating component, with separated values
                        ChargeCodeAlias = new CodedWithExceptions[]
                        {
                            new CodedWithExceptions
                            {
                                Identifier = "Code 1",
                                Text = "ABC"
                            },
                            new CodedWithExceptions
                            {
                                Identifier = "Code 2",
                                Text = "ZYX"
                            }
                        }
                    },

                    new In1Segment
                    {
                        Ordinal = 1,

                        SetIdIn1 = 15,
                        HealthPlanId = new CodedWithExceptions
                        {
                            Identifier = "MNO Healthcare"
                        },

                        // Component with subcomponents
                        InsuranceCompanyId = new ExtendedCompositeIdWithCheckDigit[]
                        {
                            new ExtendedCompositeIdWithCheckDigit
                            {
                                IdNumber = "736HB",
                                AssigningAuthority = new HierarchicDesignator
                                {
                                    NamespaceId = "DES1",
                                    UniversalId = "UID654",
                                    UniversalIdType = "Type 5"
                                }
                            },
                            new ExtendedCompositeIdWithCheckDigit
                            {
                                IdNumber = "AA876",
                                AssigningAuthority = new HierarchicDesignator
                                {
                                    NamespaceId = "LLL098",
                                    UniversalId = "UID123",
                                    UniversalIdType = "Type 7"
                                }
                            }
                        }
                    }
                }
            };

            string expected = $"MSH|^~\\&|Sender 1||Receiver 1||20201202144539|||||2.9{ Consts.LineTerminator }IN1|15|MNO Healthcare|736HB^^^DES1&UID654&Type 5~AA876^^^LLL098&UID123&Type 7{ Consts.LineTerminator }CDM||Code 1^ABC~Code 2^ZYX{ Consts.LineTerminator }";
            string actual = message.ToDelimitedString();

            Assert.Equal(expected, actual);
        }
    }
}
