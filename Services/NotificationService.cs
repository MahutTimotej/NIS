using System;

namespace NIS.Services
{
    public sealed class NotificationMessage
    {
        public string Type { get; init; } = "info";
        public string Text { get; init; } = "";
        public int DurationMs { get; init; } = 3500;
    }

    public sealed class NotificationService
    {
        public event Action<NotificationMessage>? OnMessage;

        private void Send(string type, string text, int durationMs)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            OnMessage?.Invoke(new NotificationMessage
            {
                Type = type,
                Text = text.Trim(),
                DurationMs = durationMs
            });
        }

        public void Success(string text, int durationMs = 3500) => Send("success", text, durationMs);
        public void Warning(string text, int durationMs = 5000) => Send("warning", text, durationMs);
        public void Error(string text, int durationMs = 7000) => Send("danger", text, durationMs);
        public void Info(string text, int durationMs = 4000) => Send("info", text, durationMs);
    }
}
