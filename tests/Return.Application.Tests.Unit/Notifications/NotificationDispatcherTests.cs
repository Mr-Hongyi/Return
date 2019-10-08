﻿// ******************************************************************************
//  © 2019 Sebastiaan Dammann | damsteen.nl
// 
//  File:           : NotificationDispatcherTests.cs
//  Project         : Return.Application.Tests.Unit
// ******************************************************************************

namespace Return.Application.Tests.Unit.Notifications {
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Notifications;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public sealed class NotificationDispatcherTests {
        [Test]
        public async Task NotificationDispatcher_DispatchesNotification() {
            // Given
            using var dispatcher = new TestNotificationDispatcher();
            var subscriber = Substitute.For<ITestNotificationSubscriber>();
            subscriber.UniqueId.Returns(Guid.NewGuid());
            subscriber.Callback(Arg.Any<TestNotification>()).Returns(Task.CompletedTask);

            var subscriber2 = Substitute.For<ITestNotificationSubscriber>();
            subscriber2.UniqueId.Returns(Guid.NewGuid());
            subscriber2.Callback(Arg.Any<TestNotification>()).Returns(Task.CompletedTask);

            var notification = new TestNotification();

            // When
            dispatcher.Subscribe(subscriber);
            dispatcher.Subscribe(subscriber2);
            GC.Collect();

            await dispatcher.Dispatch(notification, CancellationToken.None);

            // Then
            await (subscriber.Received(1).Callback(notification) ?? Task.CompletedTask);
        }


        private sealed class TestNotificationDispatcher : NotificationDispatcher<TestNotification, ITestNotificationSubscriber> {
            protected override Task DispatchCore(ITestNotificationSubscriber subscriber, TestNotification notification) => subscriber.Callback(notification);
        }
    }

    public sealed class TestNotification : INotification { }

    public interface ITestNotificationSubscriber : ISubscriber {
        Task Callback(TestNotification notification);
    }
}
