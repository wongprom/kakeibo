---
description: "Load when specifying Kakeibo screens, shadcn/ui component choices, copy, or accessibility for plan month, log spending, or review."
---

# Kakeibo UX guidance

Target: `/projects/kakeibo` in `wongprom/test-next-13`. **shadcn/ui** +
Tailwind, English copy, currency **Kr**, primary action dark blue.

When the user supplies a Figma frame, also load `kakeibo-figma`.

## v1 screens

| Screen | Purpose | Typical shadcn/ui components |
| --- | --- | --- |
| Plan month | Income, fixed outflows, available, savings goal, weekly allowance | `Card`, `Form`, `Input`, `Label`, `Table`, `Separator`, `Button`, `Tooltip` |
| Log spending | Weekly / category entries, quick add | `Table`, `Dialog` or `Sheet`, `Select`, `Input`, `Calendar` + `Popover`, `Tabs` (weeks), `Badge` |
| Review | End-of-month reflection prompts | `Card`, `Textarea`, `Progress`, `Accordion`, `AlertDialog` (confirm finish) |

## Mindful friction (keep visible)

- Plan: show the savings goal and "available to spend" before the user
  commits; a short "What matters most this month?" prompt is welcome.
- Log: category is chosen by the user; no silent defaults. A light
  "Was this a need or a want?" nudge is optional, never blocking noise.
- Review: reflection prompts come first, numbers support them. Finishing a
  month uses an explicit confirmation.

## Copy tone

Calm, plain, non-judgmental English. Say "You spent Kr 1 200 on Food", not
"You overspent!". Errors say what happened and what to do next. Currency as
`Kr 1 200`.

## Accessibility checklist

- Every input has a visible `Label`; errors tied via `aria-describedby`.
- Logical focus order; dialogs trap and restore focus; Esc closes.
- Full keyboard use; visible focus ring; touch targets at least 44 px.
- Do not rely on color alone (pair status color with text or icon).
- Contrast at least WCAG AA; respect `prefers-reduced-motion`.
- Announce async results (saved, error) with a polite live region / toast.

## Out of scope (later)

AI suggestions, reflection chat, receipt upload, streamed replies.
